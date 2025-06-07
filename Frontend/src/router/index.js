import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import FormGasto from '@/views/FormGasto.vue'
import ListaGastos from '@/views/ListaGastos.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/formulario',
      name: 'formulario',
      component: FormGasto,
    },
    {
      path: '/lista',
      name: 'lista',
      component: ListaGastos,
    },
  ],
})

export default router
