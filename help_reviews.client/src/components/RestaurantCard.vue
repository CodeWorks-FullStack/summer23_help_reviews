<template>
  <div class="card">
    <router-link :to="{name: 'RestaurantDetails', params:{restaurantId: restaurant.id}}">
      <img class="rest-img rounded-top" :src="restaurant.imgUrl" alt="">
    </router-link>
    <h3 class="text-success">{{ restaurant.name }}</h3>
    <p>{{ restaurant.description }}</p>
    <div class="d-flex">
      <p><i class="mdi mdi-account-multiple-outline me-1"></i><b class="me-1">{{ restaurant.visits }}</b> recent visits</p>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Restaurant } from '../models/Restaurant.js';
export default {
  props: {
    restaurant: {type: Restaurant, required: true}
  },
  setup(){
  return {  }
  }
};
</script>

<style lang="scss" scoped>
.rest-img{
  height: 45vh;
  object-fit: cover;
  width: 100%;
}
</style>