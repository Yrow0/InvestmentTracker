<template>
  <div class="grid grid-cols-6 gap-4 m-2 border-solid border-1 border-zinc-700 rounded">
    <div class="col-span-2 m-2">
      <Card>
      <template #title>
        <h2>Chart</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[8rem]" />
      </template>
    </Card>
    </div>
    <div class="col-span-2 m-2">
      <Card>
        <template #title>
        <h2>Chart</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[8rem]" />
      </template>
      </Card>

    </div>
    <div class="col-span-2 m-2">
      <Card>
        <template #title>
        <h2>Chart</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[8rem]" />
      </template>
      </Card>

    </div>
    <div class="col-span-3 m-2">
      <Card>
      <template #title>
        <h2>Chart</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[30rem]" />
      </template>
    </Card>
    </div>
    <div class="col-span-2 m-2">
      <Card>
        <template #title>
        <h2>Chart</h2>
      </template>
      <template #content>
        <Chart type="line" :data="chartData" :options="chartOptions" class="h-[30rem]" />
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
            },
            {
                label: 'Second Dataset',
                data: [28, 48, 40, 19, 86, 27, 90],
                fill: false,
                borderColor: documentStyle.getPropertyValue('--p-red-500'),
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
