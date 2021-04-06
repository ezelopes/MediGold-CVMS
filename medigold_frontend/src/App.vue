<template>
  <div id="app">
    <div id="nav">
      <b-navbar toggleable="lg" type="dark" variant="info">
        <b-navbar-brand href="#" id='cvms'>CVMS</b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item href="/">Home</b-nav-item>
            <b-nav-item href="/covidPatients">Covid Patients</b-nav-item>
            <b-nav-item href="/registerPatient">Register Patients</b-nav-item>
            <b-nav-item href="/dashboard">Dashboard</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <router-view/>
  </div>
</template>

<style lang="scss">

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#cvm {
  cursor: default;
}

#nav {
  margin-bottom: 2em;
}

.bg-info {
    background-color: #A2924F!important;
}
</style>
