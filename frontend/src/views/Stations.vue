<script setup>
const estacoes = [
  { nome: "Estação Luz", status: "Conforme", score: "92%" },
  { nome: "Estação Brás", status: "Atenção", score: "78%" },
  { nome: "Estação Barra Funda", status: "Conforme", score: "88%" }
]
</script>

<template>
  <div class="container">
    <h1>Estações Monitoradas</h1>

    <div v-for="e in estacoes" :key="e.nome" class="card">
      <h3>{{ e.nome }}</h3>
      <p>Status: {{ e.status }}</p>
      <p>Sustentabilidade: {{ e.score }}</p>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
}

.card {
  border: 1px solid #ccc;
  padding: 20px;
  border-radius: 10px;
  margin-bottom: 15px;
}
</style>