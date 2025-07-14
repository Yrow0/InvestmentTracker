
<template>
    <div class="card">
        <DataTable :value="props.transactions" paginator :rows="5" :rowsPerPageOptions="[5, 10, 20, 50]" tableStyle="min-width: 50rem " 
                paginatorTemplate="RowsPerPageDropdown FirstPageLink PrevPageLink CurrentPageReport NextPageLink LastPageLink"
                currentPageReportTemplate="{first} to {last} of {totalRecords}">
            <Column field="category.name" header="Catégorie" style="width: 25%"></Column>
            <Column field="amount" header="Montant" style="width: 25%"></Column>
            <Column field="date" header="Date" style="width: 25%"></Column>
            <Column field="description" header="Commentaire" style="width: 25%"></Column>
            <Column header="Type" style="width: 25%">
                <template #body="slotProps">
                    <LazyTag :value="slotProps.data.type.name" :severity="getSeverity(slotProps.data)" rounded/>
                </template>
            </Column>
        </DataTable>
    </div>
</template>

<script setup lang="ts">
import { Transaction } from '~/shared/types/Transaction';

const props = defineProps<{transactions : Transaction[]}>();

onMounted(() => {
});

const getSeverity = (transaction: Transaction) : string => {
    switch (transaction.typeId) {
        case 1:
            return 'success';

        case 2:
            return 'danger';
        default:
            return '';
    }
};
 
</script>
