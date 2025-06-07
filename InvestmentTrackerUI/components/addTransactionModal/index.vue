<template>
  <Dialog :visible="visible" @update:visible="onVisibleUpdate" modal header="Ajouter une transaction" :style="{ width: '30rem' }">
    
    <div class="flex items-center gap-4 mb-4 ">
      <label for="type" class="font-semibold w-24">Type</label>
      <Select id="type" class="flex-auto" autocomplete="off" v-model="selectedType" :options="types" option-label="name" showClear/>
    </div>
    <div class="flex items-center gap-4 mb-4">
      <label for="category" class="font-semibold w-24">Catégorie</label>
      <Select id="category" class="flex-auto" autocomplete="off" v-model="selectedCategory" :options="categories" option-label="name" showClear />
    </div>
    <div class="flex items-center gap-4 mb-4">
      <label for="amount" class="font-semibold w-24">Montant</label>
      <InputNumber id="amount" class="flex-auto" autocomplete="off" :min-fraction-digits="0" :max-fraction-digits="2" />
    </div>
    <div class="flex items-center gap-4 mb-8">
      <label for="comment" class="font-semibold w-24">Commentaire</label>
      <Textarea id="comment" class="flex-auto" v-model="comment" row="5" cols="50"/>
    </div>
    <div class="flex justify-end gap-2">
      <Button type="button" label="Annuler" severity="secondary" @click="closeModal" />
      <Button type="button" label="Ajouter" @click="closeModal" />
    </div>
  </Dialog>
</template>

<script lang="ts" setup>

const props = defineProps<{ visible: boolean }>()
const emit = defineEmits<{ (e: 'update:visible', value: boolean): void }>()

function closeModal() {
  emit('update:visible', false)
}

function onVisibleUpdate(val: boolean) {
  emit('update:visible', val)
}

const selectedType = ref();
const types = ref(
    [
        {name :'Entrée'},
        {name : 'Sortie'}
    ]
)

const selectedCategory = ref();
const categories = ref(
    [
        {name :'Salaire'},
        {name : 'Investissement'},
        {name :'Nourriture'},
        {name : 'Transport'}
    ]
)

const comment = ref();
</script>
