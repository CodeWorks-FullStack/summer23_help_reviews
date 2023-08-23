<template>
  <div class="container-fluid">
    <div class="row p-3">
      <div class="col-md-4 mb-3" v-for="r in restaurants" :key="r.id">
        <RestaurantCard :restaurant="r" />
      </div>
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import {restaurantsService} from '../services/RestaurantsService.js'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {

    async function getRestaurants(){
      try {
        await restaurantsService.getRestaurants()
      } catch (error) {
        // @ts-ignore 
        Pop.error(('[ERROR]'), error.message)
      }
    }

    onMounted(() => {
      getRestaurants()
    })

    return {
      restaurants: computed(() => AppState.restaurants)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
