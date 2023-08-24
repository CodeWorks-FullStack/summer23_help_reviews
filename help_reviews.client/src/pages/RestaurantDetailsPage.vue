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
  
          <div class="col-md-6">
            <p><i class="mdi mdi-file me-1"></i><b class="me-1">{{ reports.length }}</b> reports</p>
          </div>
          
        </div>

      </div>
    </div>

    <div class="row justify-content-center mt-5">
      <div class="col-md-9">
        <h2>Reports for {{ restaurant.name }}</h2>

        <div class="row">
          <div class="col-12" v-for="r in reports" :key="r.id">
            <div class="row elevation-5 bg-white rounded mb-3 p-3">
              <div class="col-md-8">
                <p class="text-success text-center fs-4">"{{ r.title }}"</p>
                <p>{{ r.body }}</p>
              </div>
              <div class="col-md-4">
                <div class="d-flex align-items-center justify-content-end">
                  <div class="me-2">
                    <p>{{ r.creator.name }}</p>
                    <p>{{ r.createdAt }}</p>
                  </div>
                  <img class="img-fluid avatar" :src="r.creator.picture" alt="">
                </div>
              </div>
            </div>
          </div>
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
import {reportsService} from '../services/ReportsService.js'
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

    async function getReportsByRestaurantId(){
      try {
        let restaurantId = route.params.restaurantId
        await reportsService.getReportsByRestaurantId(restaurantId)
      } catch (error) {
        // @ts-ignore 
        Pop.error(('[ERROR]'), error.message)
      }
    }

    watchEffect(() =>{
      route.params.restaurantId
      getRestaurantById()
      getReportsByRestaurantId()
    })

  return { 
    restaurant: computed(() => AppState.restaurant),
    reports: computed(() => AppState.reports)
  }
  }
};
</script>


<style lang="scss" scoped>

p{
  margin: 0;
}
.avatar{
  height: 70px;
  width: 70px;
  border-radius: 50%;
  object-fit: cover;
}
</style>