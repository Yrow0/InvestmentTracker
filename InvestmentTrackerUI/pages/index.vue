<template>
  <div class="grid grid-cols-6 gap-2 border-solid border-1 border-zinc-700 rounded mx-2 mb-2">
    <div class="col-span-1 mt-2 ml-2">
      <Card class="border-2 border-green-300">
        <template #title >
          <div class="flex flex-row items-center gap-2">
              <h1 class="text-green-300"> 1,400 €</h1>
              <i class="pi pi-arrow-up text-green-500 text-xs"></i>
          </div>
        </template>
        <template #content>
          <h3 class="text-zinc-400">Montant Total</h3>

        </template>
      </Card>
    </div>
    <div class="col-start-1 col-span-2 ml-2">
      <Card>
        <template #title>
          <h2>Récapitulatif</h2>
        </template>
        <template #content>
          <Donut :categories="categories" :amountsbycategory="amountByCategory"/>
        </template>
      </Card>
    </div>
    <div class="col-start-3 col-span-4 mr-2">
      <Card>
      <template #title>
        <h2>Évolution des dépenses</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[18rem]" />
      </template>
    </Card>
    </div>
    <div class="mx-2 mb-2 col-span-6">
      <Card>
        <template #title>
          <h1>Dernières Transactions</h1>
        </template>
        <template #content>
          <TransactionHistory :transactions="alltransactions"/>
        </template>
      </Card>
    </div>
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted, watch } from "vue";
import { Transaction } from "~/shared/types/Transaction";
import { GetAmountOfTransactionsByCategory, GetTransactions, GetTransactionsByMonth } from "~/services/transactionService";
import { TransactionsByMonth } from "~/shared/types/TransactionsByMonth";
import { GetAllPresentMonth} from "~/shared/utils/month"
import { GetCategories } from "~/services/categoryService";
import { Category } from "~/shared/types/Category";

const transactionsByMonth = ref<TransactionsByMonth[]>([]);
const alltransactions = ref<Transaction[]>([]);

watch(transactionsByMonth, (newVal) => {
  chartData.value = SetChartData(newVal);
});
const chartData = ref();
const chartOptions = ref();

onMounted(async () => {
  alltransactions.value = await GetTransactions();
  transactionsByMonth.value = await GetTransactionsByMonth();
  chartOptions.value = setChartOptions();
  chartData.value = SetChartData(transactionsByMonth.value);
});

function SetChartData(_transactions: TransactionsByMonth[]) {
  const documentStyle = getComputedStyle(document.documentElement);

  return {
    labels: GetAllPresentMonth(_transactions), // par exemple ['Janvier', 'Février', ...]
    datasets: [
      {
        label: 'Total', // attention : c’est `label`, pas `labels`
        backgroundColor: documentStyle.getPropertyValue('--p-green-500'),
        data: _transactions.map(monthGroup =>
          monthGroup.transactions?.reduce((sum, t) => sum + t.amount, 0) ?? 0
        ),
        borderColor: documentStyle.getPropertyValue('--p-green-500'),
        tension: 0.4
      },
      {
        label: 'Investissement', // attention : c’est `label`, pas `labels`
        backgroundColor: documentStyle.getPropertyValue('--p-orange-500'),
        data: _transactions.map(monthGroup =>
          monthGroup.transactions
          ?.filter(t => t.categoryId === 1)
          .reduce((sum, t) => sum + t.amount, 0) ?? 0
        ),
        borderColor: documentStyle.getPropertyValue('--p-orange-500'),
        tension: 0.4
      },
      {
        label: 'Nourriture', // attention : c’est `label`, pas `labels`
        backgroundColor: documentStyle.getPropertyValue('--p-yellow-500'),
        data: _transactions.map(monthGroup =>
          monthGroup.transactions
          ?.filter(t => t.categoryId === 3)
          .reduce((sum, t) => sum + t.amount, 0) ?? 0
        ),
        borderColor: documentStyle.getPropertyValue('--p-yellow-500'),
        tension: 0.4
      },
      {
        label: 'Transport', // attention : c’est `label`, pas `labels`
        backgroundColor: documentStyle.getPropertyValue('--p-blue-500'),
        data: _transactions.map(monthGroup =>
          monthGroup.transactions
          ?.filter(t => t.categoryId === 4)
          .reduce((sum, t) => sum + t.amount, 0) ?? 0
        ),
        borderColor: documentStyle.getPropertyValue('--p-blue-500'),
        tension: 0.4
      },
    ]
  };
}

const setChartOptions = () =>  {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--p-text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--p-text-muted-color');
    const surfaceBorder = documentStyle.getPropertyValue('--p-content-border-color');

    return {
        maintainAspectRatio: false,
        aspectRatio: 0.8,
        plugins: {
            tooltips: {
                mode: 'index',
                intersect: false
  },
            legend: {
                labels: {
                    color: textColor
                }
            }
      },
        scales: {
            x: {
                stacked: false,
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder
                }
            },
            y: {
                stacked: false,
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder
                }
            }
    }
    };
};



</script>
