<script>
import { GetProducts } from '@/scripts/ProductService';
import ProductComponent from './ProductComponent.vue';

export default {
  name: 'ProductsCompoent',
  data() {
    return {
      products: [],
      cart:[],
      addToCart:(product)=>{
        console.log(product);
        this.cart.push(product);
      }
    }
  },
  components: {
    ProductComponent
  },
  created() {
    GetProducts().then(response => {
      this.products = response.data;
      console.log(this.products);
    });
  }
}
</script>
<template>
  <div>
    <h1>Product</h1>
    <h2>Cart</h2>
    <div v-for="product in cart" :key="product">
      <div>{{ product }}</div>
    </div>
    <hr/>
    <div v-for="product in products" :key="product.id">
<!-- parent to child  -->
      <ProductComponent @add-to-cart="addToCart" :product="product" />
    </div>
  </div>
  </template>
  <style>

</style>
