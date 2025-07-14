<template>
  <div>
    <NuxtLayout>
      <Toast />
      <NuxtPage />
    </NuxtLayout>
  </div>
</template>

<script setup>
useHead({
  htmlAttrs: {
    lang: 'fr'
  }
})
</script>
