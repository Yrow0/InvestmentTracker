<template>
  <div class="flex">
    <AddTransactionModal v-model:visible=visible />
    <div class="">
        <Sidebar />
    </div>
    <div class="flex flex-col grow">
      <header>
      <div>
<MegaMenu :model="items" class="p-4 bg-surface-0 m-2">
    <template #end>
      <div class="gap-2 flex flex-row items-center">
        <Button type="button" label="Ajouter" icon="pi pi-plus" @click="visible = !visible" class="h-[2rem]" outlined v-tooltip.bottom="'Ajouter un transaction'"/>
        <Avatar image="/img/avatar.png" shape="circle"  size="large"/>
      </div>
    </template>
</MegaMenu>
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