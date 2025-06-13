
<template>
    <div class="card">
        <DataTable :value="props.transactions" paginator :rows="5" :rowsPerPageOptions="[5, 10, 20, 50]" tableStyle="min-width: 50rem " 
                paginatorTemplate="RowsPerPageDropdown FirstPageLink PrevPageLink CurrentPageReport NextPageLink LastPageLink"
                currentPageReportTemplate="{first} to {last} of {totalRecords}">
            <template #paginatorstart>
                <Button type="button" icon="pi pi-refresh" text />
            </template>
            <template #paginatorend>
                <Button type="button" icon="pi pi-download" text />
            </template>
            <Column field="type.name" header="Type" style="width: 25%"></Column>
            <Column field="category.name" header="Catégorie" style="width: 25%"></Column>
            <Column field="amount" header="Montant" style="width: 25%"></Column>
            <Column field="date" header="Date" style="width: 25%"></Column>
            <Column field="description" header="Commentaire" style="width: 25%"></Column>
        </DataTable>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { Transaction } from '~/models/Transaction';

const props = defineProps<{transactions : Transaction[]}>();

onMounted(() => {
});

const customers = ref([
    {
        name: 'John Doe',
        country: { name: 'USA' },
        company: 'OpenAI',
        representative: { name: 'Alice Johnson' }
    },
    {
        name: 'Marie Curie',
        country: { name: 'France' },
        company: 'CNRS',
        representative: { name: 'Jean Dupont' }
    },
    {
        name: 'Taro Yamada',
        country: { name: 'Japan' },
        company: 'Sony',
        representative: { name: 'Naoko Sato' }
    },
    {
        name: 'Carlos Mendez',
        country: { name: 'Mexico' },
        company: 'Telmex',
        representative: { name: 'Luis Ramirez' }
    },
    {
        name: 'Fatima Zahra',
        country: { name: 'Morocco' },
        company: 'Maroc Telecom',
        representative: { name: 'Khalid El Idrissi' }
    },
    {
        name: 'Lina Müller',
        country: { name: 'Germany' },
        company: 'Siemens',
        representative: { name: 'Hans Becker' }
    },
    {
        name: 'Emma Smith',
        country: { name: 'UK' },
        company: 'BBC',
        representative: { name: 'Peter Johnson' }
    },
    {
        name: 'Chen Wei',
        country: { name: 'China' },
        company: 'Huawei',
        representative: { name: 'Li Zhang' }
    }
]);
</script>
