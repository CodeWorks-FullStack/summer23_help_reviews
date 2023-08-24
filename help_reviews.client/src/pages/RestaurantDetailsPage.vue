!<template>
  <div class="container-fluid" v-if="restaurant">
    <div class="row mt-2">
      <div class="col-md-6">
        <img class="img-fluid" :src="restaurant.imgUrl" :alt="restaurant.name">
      </div>
      <div class="col-md-6">
        <h1>{{ restaurant.name }}</h1>
        <p>{{ restaurant.description }}</p>

        <div class="row">
          <div class="col-md-6">
            <p><i class="mdi mdi-account-multiple-outline me-1"></i><b class="me-1">{{ restaurant.visits }}</b> recent visits</p>
          </div>
          <!-- FIXME this is gonna be reports -->
          <!-- <div class="col-md-6">
            <p><i class="mdi mdi-file me-1"></i><b class="me-1">{{ restaurant. }}</b> reports</p>
          </div> -->
          
        </div>

      </div>
    </div>

    <div class="row justify-content-center mt-5">
      <div class="col-md-9">
        <h2>Reports for {{ restaurant.name }}</h2>

        <!-- FIXME reports will draw here -->
        <div class="row">
          <div class="col-md-12"></div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';
import { useRoute, useRouter } from 'vue-router';
import { logger } from '../utils/Logger.js';
export default {
  setup(){

    const route = useRoute()
    const router = useRouter()

    async function getRestaurantById(){
      try {
        let restaurantId = route.params.restaurantId
        await restaurantsService.getRestaurantById(restaurantId)
      } catch (error) {
        // @ts-ignore 
        // NOTE this is kinda important ...
        Pop.error(error.response.data)
        logger.log(error)
        if(error.response.data.includes('😏')){
          router.push({name: "Home"})
        }
      }
    }

    watchEffect(() =>{
      route.params.restaurantId
      getRestaurantById()
    })

  return { 
    restaurant: computed(() => AppState.restaurant)
  }
  }
};
</script>


<style lang="scss" scoped>

</style>