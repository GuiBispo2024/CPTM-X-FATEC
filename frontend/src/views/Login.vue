<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const login = ref('')
const router = useRouter()

function entrar() {
  if(login.value.trim() !== '') {
    router.push({
      path: '/inspection',
      query: { login: login.value }
    })
  }
}
</script>

<template>
  <div class="container">
    <h1>Login do Agente</h1>

    <input v-model="login" placeholder="Login" />
    <input placeholder="Senha" type="password" />

    <button @click="entrar">Entrar</button>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
  display: flex;
  flex-direction: column;
  width: 300px;
}

input {
  margin-bottom: 15px;
  padding: 8px;
}

button {
  padding: 10px;
}
</style>