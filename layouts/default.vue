<template>
  <div class="">
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
</template>

<script lang="ts" setup>

import { PrimeIcons } from '@primevue/core/api';

const items = [
  { label: 'Home', icon: PrimeIcons.HOME },
];

</script>