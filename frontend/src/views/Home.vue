<template>
  <div class="container">
    <h1>Sistema de Monitoramento Sustentável Ferroviário</h1>
    <p>
      Plataforma digital para validação ambiental e estrutural das estações.
    </p>

    <div class="cards">
      <div class="card">Sustentabilidade</div>
      <div class="card">Segurança Operacional</div>
      <div class="card">Eficiência Energética</div>
      <div class="card">Gestão de Resíduos</div>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
}

.cards {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 20px;
  margin-top: 30px;
}

.card {
  padding: 30px;
  border-radius: 10px;
  background-color: #64da99;
  text-align: center;
  font-size: 18px;
}
</style>