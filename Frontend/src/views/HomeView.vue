<template>
  <main>
    <h1>Inicio</h1>
    <button @click="$router.push('/formulario')">Cargar Gasto</button>
    <button @click="$router.push('/lista')">Ver Gastos</button>
  </main>
</template>

<script setup>
// No necesitás importar nada si no estás usando componentes adicionales
</script>

<style scoped>
main {
  padding: 2rem;
  text-align: center;
}

button {
  margin: 0.5rem;
  padding: 0.75rem 1.5rem;
  font-size: 1rem;
  cursor: pointer;
}
</style>
