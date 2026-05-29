<template>
  <div class="min-h-screen bg-gradient-to-br from-red-600 to-red-800 flex items-center justify-center px-4">
    <div class="text-center">
      <h1 class="text-9xl font-bold text-white mb-4">404</h1>
      <h2 class="text-4xl font-bold text-white mb-2">Página não encontrada</h2>
      <p class="text-red-100 mb-8 text-lg">A página que você está procurando não existe.</p>
      <RouterLink to="/home" class="btn-primary inline-block">
        ← Voltar para Home
      </RouterLink>
    </div>
  </div>
</template>

<script setup>
import { RouterLink } from 'vue-router'
</script>