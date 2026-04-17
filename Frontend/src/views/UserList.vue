<template>
  <div>
    <h1>Usuários</h1>

    <router-link to="/create">Novo usuário</router-link>

    <ul>
      <li v-for="user in users" :key="user.id">
        {{ user.name }} - {{ user.email }}

        <router-link :to="`/edit/${user.id}`">Editar</router-link>
        <button @click="remove(user.id)">Excluir</button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { getUsers, deleteUser } from "../services/userService";

const users = ref([]);

async function load() {
  users.value = await getUsers();
}

async function remove(id) {
  await deleteUser(id);
  load();
}

onMounted(load);
</script>