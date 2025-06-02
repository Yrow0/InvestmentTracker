<template>
  <div class="flex">
    <Dialog v-model:visible="visible" modal header="Add Entry" :style="{ width: '25rem' }">
            <span class="text-surface-500 dark:text-surface-400 block mb-8">Update your information.</span>
            <div class="flex items-center gap-4 mb-4">
                <label for="username" class="font-semibold w-24">Username</label>
                <InputText id="username" class="flex-auto" autocomplete="off" />
            </div>
            <div class="flex items-center gap-4 mb-8">
                <label for="email" class="font-semibold w-24">Email</label>
                <InputText id="email" class="flex-auto" autocomplete="off" />
            </div>
            <div class="flex justify-end gap-2">
                <Button type="button" label="Cancel" severity="secondary" @click="visible = false"></Button>
                <Button type="button" label="Save" @click="visible = false"></Button>
            </div>
        </Dialog>
    <div clas="">
        <Sidebar />
    </div>
    <div class="flex flex-col grow">
      <header>
      <div>
<MegaMenu :model="items" class="p-4 bg-surface-0 m-2">
    <template #end>
      <div class="gap-2 flex flex-row items-center">
        <Button type="button" label="Add Entry" icon="pi pi-plus" @click="visible = true" class="h-[2rem] "/>
        
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

import { Sidebar } from '#components';
import { PrimeIcons } from '@primevue/core/api';

const items = [
  { label: 'Home', icon: PrimeIcons.HOME },
];

const visible = ref(false);

</script>