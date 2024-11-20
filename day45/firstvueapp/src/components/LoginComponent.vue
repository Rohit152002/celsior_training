<script>
import { login } from '@/scripts/LoginService';
// import { RouterLink } from 'vue-router';

export default {
  name: 'LoginComponent',
  data() {
    return {
      email: '',
      password: '',
      login: () => {
        event.preventDefault();
        login(this.email, this.password)
          .then((response) => {
            console.log(response)
            sessionStorage.setItem("token", response.data.token)
            alert(response.data.username + ' is logged in');
          }, err => {
            console.log(err)
            alert(err.response.data.errorMessage);
          })

      }
    }
  }
}
</script>
<template>
  <div>
    <h1>Login</h1>
    <div class="formdiv">
      <form>
        <div>
          <label class="form-control" for="email">Email</label>
          <input class="form-control" type="email" id="email" v-model="email">
        </div>
        <div>
          <label class="form-control" for="password">Password</label>
          <input class="form-control" type="password" id="password" v-model="password">
        </div>
        <button class="btn btn-success" @click="login()" type="submit">Login</button>
      </form>
      <nav>

        <router-link to="/products">Products</router-link>
      </nav>
    </div>
  </div>
</template>
<style scoped>
.formdiv {
  width: 30%;
  position: absolute;
  left: 35%;
}
</style>
