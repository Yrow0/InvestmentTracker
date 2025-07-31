<template>
    <Card class="border-2 border-green-300">
        <template #title >
          <div class="flex flex-row items-center gap-2">
            
              <h1 class="{{ props.color }}"> {{ props.value }}</h1>
              <i class="pi pi-arrow-up {{  props.color }} text-xs"></i>
          </div>
        </template>
        <template #content>
          <h3 class="text-zinc-400">Montant Total</h3>

        </template>
    </Card>
</template>

<script lang="ts" setup>

const props = defineProps<{value:number, color:string}>()

</script>
