<template>
	<div class="home-container">
		<h1 class="title m-0 p-2" style="height: 5%">Rings display</h1>

		<actions-header style="height: 5%"/>

		<div class="items-container py-2" style="height: 87%">
			<div class="items-box">
				<div v-for="(item, index) in state.items" :key="index" class="item">
					<img :src="item.image" alt="item image" class="item-image">
				</div>
			</div>
		</div>

		<footer class="footer" style="height: 3%">
			<small>A sample test project to display rings and show their images developed by: Karolis Vaitkevicius</small>
		</footer>
	</div>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";
import ActionsHeader from "@/components/ActionsHeader.vue";


export default defineComponent({
	name: "Home",
	components: {
		ActionsHeader,
	},

	setup () {

		const state = reactive({
		});


		return {
			state,
		}

	},
});
</script>

<style lang="scss" scoped>
.home-container {
	height: 100vh;
}

.title {
	@include center;
	font-family: Century, Candara, Arial, sans-serif;
}

.items-container {
	background-color: #adadc8;
}

.items-box {
	display: grid;
	height: 100%;
	padding: 1em;
	overflow-y: scroll;
	grid-template-columns: repeat(8, 1fr);
	grid-template-rows: repeat(auto-fill, 20vh);
	grid-column-gap: 1em;
  grid-row-gap: 1em;
	background-color: #adadc8;
}

.item {
	@include center;
	height: 20vh;
	box-shadow: 0px 10px 10px 1px rgba(0, 0, 0, 0.78);
	border-radius: 10px 10px 10px 10px;
	padding: 1em;
	border: 0px solid #000000;
	background-color: #e6e6faba;
}

.item-image {
	max-width: 100%;
	max-height: 100%;
}

.footer {
	@include center;
	background-color: lavender;
}
</style>
