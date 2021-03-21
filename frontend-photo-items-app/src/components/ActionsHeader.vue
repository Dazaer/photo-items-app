<template>

	<div class="actions-header">
		<div class="p-2">Amount of pictures: {{itemPhotos.length}}</div>

		<div class="p-2 d-flex justify-content-center">

			<div class="p-1">
				<div>Ring</div>

				<select v-model="state.selectedItem">
					<option
						v-for="(item) in state.items"
						:key="item.id"
						:value="item">
						{{ item.name }}
					</option>
				</select>
			</div>

			<div class="p-1">
				<div>Metal</div>

				<select v-model="state.selectedMetal"
					:disabled="state.selectedItem.id === 0">
					<option value="Rose gold">Rose gold</option>
					<option value="Yellow gold">Yellow gold</option>
				</select>
			</div>

			<div class="p-1">
				<div>Shape</div>

				<select v-model="state.selectedShape"
					:disabled="state.selectedItem.id === 0">
					<option value="Cushion">Cushion</option>
					<option value="Round">Round</option>
				</select>
			</div>
		</div>

		<div class="p-2">
			<button
				:disabled="state.selectedItem.id === 0"
				class="btn btn-success"
				@click="addItem()">
				+ Add
			</button>
		</div>
	</div>

</template>

<script lang="ts">
import { computed, defineComponent, onMounted, PropType, reactive } from "vue";
import api from "@/utilities/api";
import Item from "@/models/Item";
import ItemPhoto from "@/models/ItemPhoto";
import Property from "@/models/Property";

export default defineComponent({
	name: "ActionsHeader",

	props: {
		itemPhotos: {
			type: Array as PropType<Array<ItemPhoto>>,
			required: true,
		}
	},

	setup (props, ctx) {

		const state = reactive({
			selectedItem: Item.getNullSelectedItem(),
			selectedMetal: Property.getNullSelectedProperty(),
			selectedShape: Property.getNullSelectedProperty(),
			items: Array<Item>(),
			itemPhotos: Array<ItemPhoto>(),
		});

		const itemPhotos = computed(() => state.itemPhotos);

		function addItem () {

			console.log("added");

		}

		async function fetchItems () {
			state.items.push(state.selectedItem);

			const dbItems = await api.get("items");

			if (!dbItems) {
				return;
			}

			state.items = state.items.concat(dbItems);
		}

		onMounted(() => {
			fetchItems();
		});

		return {
			state,
			addItem,
		}

	},
});
</script>

<style lang="scss" scoped>
.actions-header {
	@include center;
	background-color: lavender;
}
</style>
