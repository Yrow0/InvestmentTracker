<template>
  <Dialog :visible="visible" @update:visible="onVisibleUpdate" modal header="Ajouter une transaction" :style="{ width: '30rem' }">
    <Form v-slot="$form" @submit="onFormSubmit">
      <div class="flex items-center gap-4 mb-4 ">
            <label for="type" class="font-semibold w-24">Type</label>
            <Select name="type" id="type" class="flex-auto" autocomplete="off" v-model="selectedType" :options="types" option-label="name" showClear/>
      </div>
      <div class="flex items-center gap-4 mb-4">
        <label for="category" class="font-semibold w-24">Catégorie</label>
        <Select name="category" id="category" class="flex-auto" autocomplete="off" v-model="selectedCategory" :options="categories" option-label="name" showClear />
      </div>
      <div class="flex items-center gap-4 mb-4">
        <label for="amount" class="font-semibold w-24">Montant</label>
        <InputNumber name="amount" id="amount" class="flex-auto" autocomplete="off" :min-fraction-digits="0" :max-fraction-digits="2" v-model="amount" />
      </div>
      <div class="flex items-center gap-4 mb-4">
        <label for="amount" class="font-semibold w-24">Date</label>
        <DatePicker name="date" id="date" class="flex-auto" :min-fraction-digits="0" :max-fraction-digits="2" v-model="date" date-format="dd-mm-yy" />
      </div>
      <div class="flex items-center gap-4 mb-8">
        <label for="comment" class="font-semibold w-24">Commentaire</label>
        <Textarea name="comment" id="comment" class="flex-auto" v-model="comment" row="5" cols="50"/>
      </div>
      <div class="flex justify-end gap-2">
        <Button type="button" label="Annuler" severity="secondary" @click="closeModal" />
        <Button type="submit" severity="primary" label="Ajouter" />
      </div>
    </Form>
    
  </Dialog>
</template>

<script lang="ts" setup>


import {useToast} from "primevue/usetoast"
import { TransactionRequest } from "~/shared/types/TransactionRequest";
import { AddTransaction } from "~/services/transactionService"
import { GetCategories } from "~/services/categoryService";
import { Category } from "~/shared/types/Category";
import type { Type } from "~/shared/types/Type";
import { GetTypes } from "~/services/typeService";

  const toast = useToast();
  const props = defineProps<{ visible: boolean }>()
const emit = defineEmits<{ (e: 'update:visible', value: boolean): void }>()




function closeModal() {
  emit('update:visible', false)
}

function onVisibleUpdate(val: boolean) {
  emit('update:visible', val)
}
const amount =ref<number>();
const comment = ref<string>();
const selectedType = ref();
const selectedCategory = ref();
const date = ref<Date>(new Date());

const types = ref<Type[]>([]);
const categories = ref<Category[]>([]);

onMounted(async () => {
  categories.value = await GetCategories();
  types.value = await GetTypes();
});



const onFormSubmit = async ({ valid }: { valid: boolean }) => {
  
  try {
    const transaction = new TransactionRequest({
      typeId: selectedType.value?.id || '',
      categoryId: selectedCategory.value?.id || '',
      amount: amount.value ?? 0,  
      description: comment.value ?? '',
      date : date.value
     });

    const responseData = await AddTransaction(transaction);

    if (responseData) {
      toast.add({
        severity: 'success',
        summary: 'Transaction Ajoutée',
        life: 1250
      });
    }
    else{
      throw("error");
    }
 } catch (error: unknown) {
    const err = error as Error;

    toast.add({
      severity: 'error',
      summary: 'Erreur',
      detail: err.message || 'Erreur inconnue',
      life: 3000
    });

    console.error('Erreur lors de l\'appel API :', err);
 }
 finally{
    closeModal();
    reloadNuxtApp();
 }
}

</script>
