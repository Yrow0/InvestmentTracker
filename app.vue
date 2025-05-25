<template>
  <div>
    <MegaMenu :model="items" class="m-2"/>
  </div>
</template>

<script lang="ts" setup>
import { PrimeIcons } from '@primevue/core/api';

const items = [
  { label: 'Home', icon: PrimeIcons.HOME },
];


</script>
