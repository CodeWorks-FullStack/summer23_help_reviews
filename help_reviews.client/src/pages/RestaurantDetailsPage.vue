!<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <h1></h1>
      </div>
    </div>

  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';
export default {
  setup(){

    // async function getRestaurantById(){
    //   try {
    //     await restaurantsService.getRestaurantById()
    //   } catch (error) {
    //     // @ts-ignore 
    //     Pop.error(('[ERROR]'), error.message)
    //   }
    // }

  return {  }
  }
};
</script>


<style lang="scss" scoped>

</style>