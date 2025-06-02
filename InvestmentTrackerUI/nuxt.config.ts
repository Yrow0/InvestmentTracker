import Aura from '@primeuix/themes/aura';
import tailwindcss from '@tailwindcss/vite';

export default defineNuxtConfig({
  compatibilityDate: '2025-05-15',
  devtools: { enabled: true },
  css: ['~/assets/css/main.css'],
  vite:{
    plugins:[
    tailwindcss(),
  ]
  },
  modules : [
    '@primevue/nuxt-module'
  ],
  primevue : {
    options : {
      theme : {
        preset : Aura
      },
    },
    
  }
  })
