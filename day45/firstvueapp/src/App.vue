<template>
    <img alt="Vue logo" src="./assets/logo.png">

   <!-- <ProductList/> -->
    <!-- <LoginComponent/> -->
    <!-- <AddProductComponent/> -->
    <nav>
    <router-link to="/">Home</router-link>
    <router-link to="/login">Login</router-link>
    <router-link to="/products">Products</router-link>
  </nav>
  <router-view/>
</template>

<script>

// import ProductList from './components/ProductList.vue'; // import LoginComponent from './components/LoginComponent.vue';
// import AddProductComponent from './components/AddProductComponent.vue';


export default {
  name: 'App',
  components: {
    // ProductList
    // LoginComponent,
    // AddProductComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
