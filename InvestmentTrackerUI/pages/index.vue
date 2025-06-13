<template>
  <div class="grid grid-cols-6 gap-2 border-solid border-1 border-zinc-700 rounded mx-2 mb-2">
    <div class="col-span-1 mt-2 ml-2">
      <Card>
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
          <Donut />
        </template>
      </Card>
    </div>
    <div class="col-start-3 col-span-4 mr-2">
      <Card>
      <template #title>
        <h2>Évolution des dépenses</h2>
      </template>
      <template #content>
        <Chart type="bar" :data="chartData" :options="chartOptions" class="h-[18rem]" />
      </template>
    </Card>
    </div>
    <div class="mx-2 mb-2 col-span-6">
      <Card>
        <template #title>
          <h1>Dernières Transactions</h1>
        </template>
        <template #content>
          <TransactionHistory :transactions="transactions"/>
        </template>
      </Card>
    </div>
  </div>
</template>
<script setup lang="ts">
import { date } from "@primeuix/themes/aura/datepicker";
import { ref, onMounted, watch } from "vue";
import { Transaction } from "~/models/Transaction";
import { GetTransactions } from "~/services/transactionService";
import { MONTHS } from "~/miscs/month"

const transactions = ref<Transaction[]>([]);

watch(transactions, (newVal) => {
  chartData.value = SetChartData(newVal);
});
const chartData = ref();
const chartOptions = ref();

onMounted(async () => {
  transactions.value = await GetTransactions();
  chartOptions.value = setChartOptions();
  chartData.value = SetChartData(transactions.value);
});

function SetChartData(_transactions: Transaction[]) {
    const documentStyle = getComputedStyle(document.documentElement);
    return {
      labels:getMonthsFromTransactions(_transactions),
      datasets: [
        {
          type: 'bar',
          label: 'Investissement',
          backgroundColor: documentStyle.getPropertyValue('--p-cyan-500'),
          data : [10]
        }
      ]
    }

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
                stacked: true,
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder
                }
            },
            y: {
                stacked: true,
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


function getMonthsFromTransactions(transactions: Transaction[]): string[] {
  const monthsSet = new Set<string>();

  transactions.forEach(tx => {
    if (!tx.date) return; // Skip si date est undefined/null

    const date = new Date(tx.date); // tx.date est maintenant sûr
    if (!isNaN(date.getTime())) {
      monthsSet.add(MONTHS[date.getMonth()]);
    }
  });
  console.log(monthsSet);
  return Array.from(monthsSet).sort();
}



</script>
