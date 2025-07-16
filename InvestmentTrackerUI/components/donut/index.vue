
<template>
    <div class="card flex justify-center">
        <Chart type="doughnut" :data="chartData" :options="chartOptions" class="h-[18rem]" />
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { GetCategories } from "~/services/categoryService";
import { GetAmountOfTransactionsByCategory } from "~/services/transactionService";
import type { Category } from "~/shared/types/Category";




onMounted(async () => {
    
    categories.value = await GetCategories();
    amountsbycategory.value = await GetAmountOfTransactionsByCategory();
    chartData.value = setChartData(categories.value, amountsbycategory.value);
    chartOptions.value = setChartOptions();
});

const categories = ref<Category[]>([]);
const amountsbycategory = ref<{[id:number]: number}>([]);
const chartData = ref();
const chartOptions = ref(null);

const setChartData = (categories: Category[], amounts: {[id:number]: number}) => {
    const documentStyle = getComputedStyle(document.body);
    console.log("donut");
    console.log(categories);
    console.log(amounts);
    return {
        labels: categories.map(c=> c.name),
        datasets: [
            {
                data: categories.map(c => amounts[c.id] ?? 0),
                backgroundColor: [documentStyle.getPropertyValue('--p-red-500'), documentStyle.getPropertyValue('--p-orange-500'), documentStyle.getPropertyValue('--p-stone-500'), documentStyle.getPropertyValue('--p-blue-500')],
                hoverBackgroundColor: [documentStyle.getPropertyValue('--p-red-400'), documentStyle.getPropertyValue('--p-orange-400'), documentStyle.getPropertyValue('--p-stone-400'), documentStyle.getPropertyValue('--p-blue-400')],
                borderWidth: 0,
            }
        ]
    };
};

const setChartOptions = () => {
    const documentStyle = getComputedStyle(document.documentElement);
    const textColor = documentStyle.getPropertyValue('--p-text-color');

    return {
        cutout : '85%',
        plugins: {
            legend: {
                labels: {
                    cutout: '60%',
                    color: textColor
                }
            }
        }
    };
};
</script>
