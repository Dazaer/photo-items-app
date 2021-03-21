<template>

	<div class="actions-header">
		<div class="p-2">Amount: {{state.items.length - 1}}</div>

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

				<select v-model="state.selectedMetalType"
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
import { defineComponent, onMounted, reactive } from "vue";
import api from "@/utilities/api";
import Item from "@/models/Item";
import Property from "@/models/Property";

export default defineComponent({
	name: "ActionsHeader",

	setup (props, ctx) {

		const state = reactive({
			selectedShape: Property.getNullSelectedProperty(),
			selectedMetalType: Property.getNullSelectedProperty(),
			selectedItem: Item.getNullSelectedItem(),
			items: Array<Item>(),
		});

		function addItem () {

			console.log("added");

		}


		async function fetchItems () {
			state.items.push(Item.getNullSelectedItem());

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
