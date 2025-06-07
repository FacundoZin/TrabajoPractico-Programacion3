<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'
import { useToast } from 'vue-toastification'

const gastos = ref([])
const loading = ref(false)
const error = ref(null)
const toast = useToast()

const fetchGastos = async () => {
  loading.value = true
  error.value = null
  try {
    const res = await axios.get('http://localhost:5115/api/gastos')
    gastos.value = res.data
  } catch (e) {
    console.error('Error al cargar los gastos:', e)
    error.value = 'Error al cargar los gastos'
    toast.error(error.value)
  } finally {
    loading.value = false
  }
}

onMounted(() => {
  fetchGastos()
})
</script>

<template>
  <div>
    <h2>Lista de Gastos</h2>

    <div v-if="loading">Cargando gastos...</div>
    <div v-if="error" class="error">{{ error }}</div>

    <table v-if="!loading && gastos.length">
      <thead>
        <tr>
          <th>Monto</th>
          <th>Descripción</th>
          <th>Fecha</th>
          <th>Nombre Comercio</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="gasto in gastos" :key="gasto.id">
          <td>{{ gasto.monto }}</td>
          <td>{{ gasto.descripcion }}</td>
          <td>{{ new Date(gasto.fecha).toLocaleDateString() }}</td>
          <td>{{ gasto.nombreComercio }}</td>
        </tr>
      </tbody>
    </table>

    <div v-if="!loading && !gastos.length">No hay gastos cargados.</div>
  </div>
</template>

<style scoped>
.error {
  color: red;
  margin-bottom: 1rem;
}
table {
  width: 100%;
  border-collapse: collapse;
}
th,
td {
  padding: 0.5rem;
  border: 1px solid #ddd;
}
th {
  background-color: #f4f4f4;
  text-align: left;
  color: #000 !important;
}
</style>
