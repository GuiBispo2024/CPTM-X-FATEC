<script setup>
import { ref } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const loginAgente = route.query.login || "Agente"

const itens = ref([
  "Trilhos",
  "Desgaste estrutural",
  "Iluminação LED",
  "Gestão de resíduos",
  "Consumo de energia"
])
</script>

<template>
  <div class="container">
    <h2>Bem-vindo, {{ loginAgente }}</h2>
    <h1>Checklist de Inspeção</h1>

    <div v-for="item in itens" :key="item" class="item">
      <span>{{ item }}</span>

      <div>
        <button class="ok">Conforme</button>
        <button class="warn">Atenção</button>
        <button class="bad">Não Conforme</button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
}

.item {
  border: 1px solid #ddd;
  padding: 15px;
  border-radius: 8px;
  margin-bottom: 15px;
  display: flex;
  justify-content: space-between;
}

.ok {
  background-color: #28a745;
  color: white;
  margin-right: 5px;
}

.warn {
  background-color: #ffc107;
  margin-right: 5px;
}

.bad {
  background-color: #dc3545;
  color: white;
}
</style>