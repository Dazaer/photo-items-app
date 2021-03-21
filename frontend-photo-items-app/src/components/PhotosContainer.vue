<template>
	<div class="photos-container">

		<div v-for="(itemPhoto) in itemPhotos" :key="itemPhoto.id" class="item-photo">
			<img :src="itemPhoto.fileName" :alt="itemPhoto.alt ?? 'Photo not available'" class="image">
		</div>

	</div>
</template>

<script lang="ts">
import ItemPhoto from "@/models/ItemPhoto";
import { defineComponent, PropType, reactive } from "vue";

export default defineComponent({
	name: "PhotosContainer",

  props: {
		itemPhotos: {
			type: Array as PropType<Array<ItemPhoto>>,
			required: true,
		}
  },

	setup (props, ctx) {

		const state = reactive({
		});


		return {
			state,
		}

	},
});
</script>

<style lang="scss" scoped>

.photos-container {
	display: grid;
	height: 100%;
	padding: 1em;
	overflow-y: scroll;
	grid-template-columns: repeat(6, 1fr);
	grid-template-rows: repeat(auto-fill, 30vh);
	grid-column-gap: 1em;
	grid-row-gap: 1em;
	background-color: #adadc8;

	.item-photo {
		@include center;
		height: 30vh;
		box-shadow: 0px 10px 10px 1px rgba(0, 0, 0, 0.78);
		border-radius: 10px 10px 10px 10px;
		padding: 1em;
		border: 0px solid #000000;
		background-color: #e6e6faba;

		.image {
			max-width: 100%;
			max-height: 100%;
		}
	}

}
</style>
