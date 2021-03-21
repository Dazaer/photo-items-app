<template>
	<div class="home-container">
		<h1 class="title m-0 p-2" style="height: 7%">The Rings Collection</h1>

		<actions-header v-if="finishedFetching" @photos-filtered="applyFilter" @refresh-photos="fetchPhotos" :item-photos="state.itemPhotos" style="height: 10%" />

		<div class="items-container py-2" style="height: 80%">
			<photos-container :item-photos="state.filteredPhotos" />
		</div>

		<footer class="footer" style="height: 3%">
			<small>
				A sample test project to display rings and show their images developed by: Karolis Vaitkevicius
			</small>
		</footer>
	</div>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive, ref } from "vue";
import ActionsHeader from "@/components/ActionsHeader.vue";
import PhotosContainer from "@/components/PhotosContainer.vue";
import ItemPhoto from "@/models/ItemPhoto";
import api from "@/utilities/api";

export default defineComponent({
	name: "Home",
	components: {
		ActionsHeader,
		PhotosContainer,
	},

	setup () {

		let finishedFetching = ref(false);

		const state = reactive({
			itemPhotos: Array<ItemPhoto>(),
			filteredPhotos: Array<ItemPhoto>(),
		});

		async function fetchPhotos (typeId: number = 1) {
			const dbItemPhotos: ItemPhoto[] = await api.get(`itemphotos`);

			if (!dbItemPhotos) {
				return;
			}

			const filteredItemPhotos = dbItemPhotos.filter(itemPhoto => itemPhoto.typeId == typeId);

			state.itemPhotos = filteredItemPhotos;
			state.filteredPhotos = state.itemPhotos;
			finishedFetching.value = true;
		}

		function applyFilter(photos: ItemPhoto[]) {
			state.filteredPhotos = photos;
		}

		onMounted(() => {
			fetchPhotos();
		});

		return {
			state,
			fetchPhotos,
			applyFilter,
			finishedFetching,
		}

	},
});
</script>

<style lang="scss" scoped>
.home-container {
	height: 100vh;

	.items-container {
		background-color: #adadc8;
	}

	.title {
		@include center;
		font-family: Century, Candara, Arial, sans-serif;
	}

	.footer {
		@include center;
		background-color: lavender;
	}
}
</style>
