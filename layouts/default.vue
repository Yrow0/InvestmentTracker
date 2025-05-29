<template>
  <div class="flex">
    <div clas="">
        <Sidebar />
    </div>
    <div class="flex flex-col grow">
      <header>
      <div>
<MegaMenu :model="items" class="p-4 bg-surface-0 m-2">
    <template #end>
      
        <Avatar image="/img/avatar.png" shape="circle" />
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

import { Sidebar } from '#components';
import { PrimeIcons } from '@primevue/core/api';

const items = [
  { label: 'Home', icon: PrimeIcons.HOME },
];

</script>