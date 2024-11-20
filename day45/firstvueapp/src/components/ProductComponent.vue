<script>


export default {
  name: 'ProductCompoent',
  data() {
    return {
      select: (prod) => {
        console.log(prod + " selected");
        this.$emit('add-to-cart', prod);//bubble up the event
      }
    }
  },
  props: {

    product: {
      name: '',
      unitPrice: 0,
      quantity: 0,
      description: '',
      basicImage: ''

    }
  }
}
</script>
<template>
  <div>
    <h1>Product</h1>
    <div>{{ product.name }}</div>
    <button @click="select(product.name)">Add to Cart</button>
  </div>
</template>


<style></style>
