<template>
  <div>
    <h2>Cargar Gasto</h2>
    <form @submit.prevent="enviarGasto">
      <!-- Monto -->
      <div>
        <input type="number" v-model.number="gasto.monto" placeholder="Monto" />
        <p v-if="errores.monto" class="error">{{ errores.monto }}</p>
      </div>

      <!-- Descripción -->
      <div>
        <input type="text" v-model="gasto.descripcion" placeholder="Descripción" />
        <p v-if="errores.descripcion" class="error">{{ errores.descripcion }}</p>
      </div>

      <!-- Fecha -->
      <div>
        <input type="date" v-model="gasto.fecha" />
        <p v-if="errores.fecha" class="error">{{ errores.fecha }}</p>
      </div>

      <!-- Nombre del comercio -->
      <div>
        <input type="text" v-model="gasto.nombreComercio" placeholder="Nombre del Comercio" />
        <p v-if="errores.nombreComercio" class="error">{{ errores.nombreComercio }}</p>
      </div>

      <button type="submit">Enviar</button>
    </form>
  </div>
</template>

<script setup>
import { reactive } from 'vue'
import axios from 'axios'
import { useToast } from 'vue-toastification'

const toast = useToast()

const gasto = reactive({
  monto: null,
  descripcion: '',
  fecha: '',
  nombreComercio: '',
})

const errores = reactive({
  monto: '',
  descripcion: '',
  fecha: '',
  nombreComercio: '',
})

const limpiarErrores = () => {
  for (const key in errores) {
    errores[key] = ''
  }
}

const validarFront = () => {
  let valido = true
  limpiarErrores()

  if (!gasto.monto || gasto.monto <= 0) {
    errores.monto = 'El monto debe ser mayor a 0.'
    valido = false
  }

  if (!gasto.descripcion || gasto.descripcion.length < 3 || gasto.descripcion.length > 250) {
    errores.descripcion = 'La descripción debe tener entre 3 y 250 caracteres.'
    valido = false
  }

  if (!gasto.fecha) {
    errores.fecha = 'La fecha es obligatoria.'
    valido = false
  } else if (new Date(gasto.fecha) > new Date()) {
    errores.fecha = 'La fecha no puede ser futura.'
    valido = false
  }

  if (!gasto.nombreComercio || gasto.nombreComercio.trim().length === 0) {
    errores.nombreComercio = 'El nombre del comercio es obligatorio.'
    valido = false
  }

  return valido
}

const enviarGasto = async () => {
  if (!validarFront()) return

  try {
    await axios.post('http://localhost:5115/api/gastos', gasto)
    toast.success('Gasto cargado con éxito 🎉')
    gasto.monto = null
    gasto.descripcion = ''
    gasto.fecha = ''
    gasto.nombreComercio = ''
  } catch (error) {
    console.error('Error al enviar gasto:', error) // Esto siempre imprime el error

    if (error.response?.status === 400 && error.response.data?.errors) {
      const apiErrors = error.response.data.errors

      errores.monto = apiErrors.Monto?.[0] || ''
      errores.descripcion = apiErrors.Descripcion?.[0] || ''
      errores.fecha = apiErrors.Fecha?.[0] || ''
      errores.nombreComercio = apiErrors.NombreComercio?.[0] || ''
    } else {
      toast.error('Error inesperado al cargar el gasto 😕')
    }
  }
}
</script>

<style scoped>
form {
  max-width: 500px;
  margin: 2rem auto;
  padding: 2rem;
  border: 1px solid #ddd;
  border-radius: 8px;
  background-color: #f9f9f9;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

h2 {
  text-align: center;
  margin-bottom: 1.5rem;
  font-size: 1.5rem;
  color: #333;
}

form div {
  margin-bottom: 1.2rem;
}

input[type='text'],
input[type='number'],
input[type='date'] {
  width: 100%;
  padding: 0.6rem;
  font-size: 1rem;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
}

button {
  width: 100%;
  padding: 0.8rem;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 1.1rem;
  cursor: pointer;
  transition: background-color 0.2s ease-in-out;
}

button:hover {
  background-color: #37956e;
}

.error {
  color: red;
  font-size: 0.85rem;
  margin-top: 0.3rem;
}
</style>
