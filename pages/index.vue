<template>
  <div class="grid grid-cols-6 gap-2 border-solid border-1 border-zinc-700 rounded mx-2 mb-2">
    <div class="col-span-1 mt-2 ml-2">
      <Card>
        <template #title >
          <div class="flex flex-row items-center gap-2">
              <h1 class="text-green-300"> $ 24,450</h1>
              <i class="pi pi-arrow-up text-green-500 text-xs"></i>
          </div>
        </template>
        <template #content>
          <h3 class="text-zinc-400">Total Balance</h3>

        </template>
      </Card>
    </div>
    <div class="col-start-1 col-span-3 ml-2">
      <Card>
        <template #title>
          <h2>Récap</h2>
        </template>
        <template #content>
          <Donut />
        </template>
      </Card>
    </div>
    <div class="col-start-4 col-span-3 mr-2">
      <Card>
      <template #title>
        <h2>Évolution du patrimoire</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[18rem]" />
      </template>
    </Card>
    </div>
    <div class="mx-2 mb-2 col-span-6">
      <Card>
        <template #title>
          <h1>Your cryptos</h1>
        </template>
        <template #content>
          <Cointable />
        </template>
      </Card>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";

onMounted(() => {
    chartData.value = setChartData();
    chartOptions.value = setChartOptions();
});

const chartData = ref();
const chartOptions = ref();
        
const setChartData = () => {
    const documentStyle = getComputedStyle(document.documentElement);

    return {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [
            {
                label: 'First Dataset',
                data: [65, 59, 80, 81, 56, 55, 40],
                fill: false,
                borderColor: documentStyle.getPropertyValue('--p-green-500'),
                tension: 0
            }
        ]
    };
};
const setChartOptions = () => {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--p-text-color');
    const textColorSecondary = documentStyle.getPropertyValue('--p-text-muted-color');
    const surfaceBorder = documentStyle.getPropertyValue('--p-content-border-color');

    return {
        maintainAspectRatio: false,
        aspectRatio: 0.6,
        plugins: {
            legend: {
                labels: {
                    color: textColor
                }
            }
        },
        scales: {
            x: {
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder
                }
            },
            y: {
                ticks: {
                    color: textColorSecondary
                },
                grid: {
                    color: surfaceBorder
                }
            }
        },
        
    };
}
</script>
