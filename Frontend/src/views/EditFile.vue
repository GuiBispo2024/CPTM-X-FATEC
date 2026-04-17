<template>
  <div>
    <h1>Editar usuário</h1>

    <form @submit.prevent="save">
      <input v-model="form.name" placeholder="Nome" required />
      <input v-model="form.email" placeholder="Email" required />
      <input v-model="form.password" type="password" placeholder="Nova senha (opcional)" />

      <button type="submit">Atualizar</button>
    </form>
  </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { getUsers, updateUser } from "../services/userService";

const route = useRoute();
const router = useRouter();

const form = reactive({
  name: "",
  email: "",
  password: "",
});

onMounted(async () => {
  const users = await getUsers();
  const user = users.find(u => u.id == route.params.id);

  if (user) {
    form.name = user.name;
    form.email = user.email;
  }
});

async function save() {
  await updateUser(route.params.id, form);
  router.push("/");
}
</script>