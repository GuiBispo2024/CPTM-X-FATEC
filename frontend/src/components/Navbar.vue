<template>
  <nav class="navbar">
    <div class="logo-area">
      <img src="/cptm_logo1.png" width="70px" alt="Logo CPTM" class="logo" />
      <h2>Sistema Sustentável CPTM X FATEC</h2>
    </div>
    <div class="links">
      <router-link to="/">Home</router-link>
      <router-link to="/stations">Estações</router-link>
      <router-link to="/inspection">Inspeção</router-link>
      <router-link to="/login">Login</router-link>
    </div>
  </nav>
</template>

<style scoped>
.navbar {
  background-color: #a8a8a8;
  color: white;
  padding: 15px 30px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.links a {
  margin-left: 20px;
  color: white;
  text-decoration: none;
}

.links a:hover {
  text-decoration: underline;
}

.logo-area {
  display: flex;
  align-items: center;
  gap: 15px;
}
</style>