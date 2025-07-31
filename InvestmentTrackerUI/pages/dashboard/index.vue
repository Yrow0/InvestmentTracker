<template>
  <div class="grid grid-cols-6 gap-2 mx-2 mb-2">
    
    <div class="col-start-1 col-span-4 ml-2">
      <Card>
      <template #title>
        <h2>Évolution des dépenses</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[18rem]" />
      </template>
    </Card>
    </div>
    <div class="col-span-2 mr-2">
      <Card>
        <template #title>
          <h2>Récapitulatif</h2>
        </template>
        <template #content>
          <Donut/>
        </template>
      </Card>
    </div>
    <div  class="col-span-1 mt-2 ml-2 text-[20px] font-bold">
      <h1>
        Chiffres Clés:
      </h1>
    </div>
    <div class="col-start-1 col-span-1 mt-2 ml-2">
      <NumberCard :value="123" color="text-green-500"/>
    </div>
    <div class="col-start-2 col-span-1 mt-2 ml-2">
      <NumberCard :value="123" color="text-yellow-500"/>
    </div>
<!--     
    <div class="mx-2 mb-2 col-span-6">
      <Card>
        <template #title>
          <h1>Dernières Transactions</h1>
        </template>
        <template #content>
          <TransactionHistory :transactions="alltransactions"/>
        </template>
      </Card>
    </div> -->
  </div>
</template>
<script setup lang="ts">
import { ref, onMounted, watch } from "vue";
import { Transaction } from "~/shared/types/Transaction";
import { GetTransactions, GetTransactionsByMonth } from "~/services/transactionService";
import { TransactionsByMonth } from "~/shared/types/TransactionsByMonth";
import { GetAllPresentMonth} from "~/shared/utils/month"

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
        backgroundColor: 'rgba(0,150,0, 0.2)',
        data: _transactions.map(monthGroup =>
          monthGroup.transactions?.reduce((sum, t) => sum + t.amount, 0) ?? 0
        ),
        borderColor: documentStyle.getPropertyValue('--p-green-500'),
        tension: 0.4,
        fill:true,
      },
      // {
      //   label: 'Investissement', // attention : c’est `label`, pas `labels`
      //   backgroundColor: documentStyle.getPropertyValue('--p-orange-500'),
      //   data: _transactions.map(monthGroup =>
      //     monthGroup.transactions
      //     ?.filter(t => t.categoryId === 1)
      //     .reduce((sum, t) => sum + t.amount, 0) ?? 0
      //   ),
      //   borderColor: documentStyle.getPropertyValue('--p-orange-500'),
      //   tension: 0.4
      // },
      // {
      //   label: 'Nourriture', // attention : c’est `label`, pas `labels`
      //   backgroundColor: documentStyle.getPropertyValue('--p-yellow-500'),
      //   data: _transactions.map(monthGroup =>
      //     monthGroup.transactions
      //     ?.filter(t => t.categoryId === 3)
      //     .reduce((sum, t) => sum + t.amount, 0) ?? 0
      //   ),
      //   borderColor: documentStyle.getPropertyValue('--p-yellow-500'),
      //   tension: 0.4
      // },
      // {
      //   label: 'Transport', // attention : c’est `label`, pas `labels`
      //   backgroundColor: documentStyle.getPropertyValue('--p-blue-500'),
      //   data: _transactions.map(monthGroup =>
      //     monthGroup.transactions
      //     ?.filter(t => t.categoryId === 4)
      //     .reduce((sum, t) => sum + t.amount, 0) ?? 0
      //   ),
      //   borderColor: documentStyle.getPropertyValue('--p-blue-500'),
      //   tension: 0.4
      // },
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
