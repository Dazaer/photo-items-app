<template>
	<div class="container-fluid row">
		<h1 class="col-md-2">Rings display</h1>
	</div>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";

export default defineComponent({
	name: "Home",
	components: {
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

</style>
