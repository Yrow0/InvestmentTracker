<template>
  <div class="flex">
    <AddTransactionModal v-model:visible=visible />
    <div class="">
        <CustomSideBar />
    </div>
    <div class="flex flex-col grow">
      <header>
      <div>
<Menubar class="p-4 border-none m-2">
    <template #end>
      <div class="gap-2 flex flex-row items-center">
        <Button type="button" label="Ajouter une transaction" icon="pi pi-plus" @click="visible = !visible" class="h-[2rem]" rounded outlined v-tooltip.bottom="'Ajouter un transaction'"/>
        <!-- <Avatar image="/img/avatar.png" shape="circle"  size="large"/> -->
      </div>
    </template>
</Menubar>
      </div>
    </header>
    <div>
      <slot />
    </div>
    </div>
  </div>
</template>

<script lang="ts" setup>

import { PrimeIcons } from '@primevue/core/api';

const items = [
  { label: 'Home', icon: PrimeIcons.HOME },
];

const visible = ref(false);

</script>

<style scoped>
::v-deep(.p-menubar) {
  border: none !important;
  background-color: transparent !important;
  box-shadow: none !important; /* removes any elevation/shadow */
}

::v-deep(.p-menubar-root-list) {
  background-color: transparent !important;
}
</style>