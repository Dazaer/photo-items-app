<template>
	<div class="home-container">
		<h1 class="title m-0 p-2" style="height: 5%">Rings display</h1>

		<actions-header :item-photos="state.itemPhotos" style="height: 5%" />

		<div class="items-container py-2" style="height: 87%">
			<photos-container :item-photos="state.itemPhotos" />
		</div>

		<footer class="footer" style="height: 3%">
			<small>
				A sample test project to display rings and show their images developed by: Karolis Vaitkevicius
			</small>
		</footer>
	</div>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from "vue";
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

		const state = reactive({
			itemPhotos: Array<ItemPhoto>(),
		});

		async function fetchItemPhotos (typeId: number = 1, itemId?: number) {
			const dbItemPhotos = await api.get(`itemphotos?typeId=${typeId}&itemId=${itemId}`);

			if (!dbItemPhotos) {
				return;
			}

			state.itemPhotos = state.itemPhotos.concat(dbItemPhotos);
		}

		onMounted(() => {
			fetchItemPhotos();
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
