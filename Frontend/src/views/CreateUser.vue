<template>
  <div>
    <h1>Criar usuário</h1>

    <form @submit.prevent="save">
      <input v-model="form.name" placeholder="Nome" required />
      <input v-model="form.email" placeholder="Email" required />
      <input v-model="form.password" type="password" placeholder="Senha" required />

      <button type="submit">Salvar</button>
    </form>
  </div>
</template>

<script setup>
import { reactive } from "vue";
import { useRouter } from "vue-router";
import { createUser } from "../services/userService";

const router = useRouter();

const form = reactive({
  name: "",
  email: "",
  password: "",
});

async function save() {
  await createUser(form);
  router.push("/");
}
</script>   