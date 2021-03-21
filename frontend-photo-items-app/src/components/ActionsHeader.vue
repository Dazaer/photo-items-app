<template>

	<div class="actions-header">
		<div class="p-2">Amount of pictures: {{itemPhotos.length}}</div>

		<div class="p-2 d-flex justify-content-center">

			<div class="p-1">
				<div>Ring</div>

				<select v-model="state.selectedItem" @change="itemChanged()">
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
					<option
						v-for="(metalType) in state.metalTypes"
						:key="metalType.id"
						:value="metalType">
						{{ metalType.description }}
					</option>
				</select>
			</div>

			<div class="p-1">
				<div>Shape</div>

				<select v-model="state.selectedShape"
					:disabled="state.selectedItem.id === 0">
					<option
						v-for="(shapeType) in state.shapeTypes"
						:key="shapeType.id"
						:value="shapeType">
						{{ shapeType.description }}
					</option>
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
import Metal from "@/models/virtual/Metal";
import Shape from "@/models/virtual/Shape";
import MetalType from "@/models/virtual/MetalType";
import ShapeType from "@/models/virtual/ShapeType";
import PropertyType from "@/models/virtual/PropertyType";
import ItemPhotoPropertySet from "@/models/ItemPhotoPropertySet";

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
			selectedMetal: Property.getNullSelectedPropertyType<MetalType>(),
			selectedShape: Property.getNullSelectedPropertyType<ShapeType>(),
			items: Array<Item>(),
			metalTypes: Array<PropertyType<MetalType>>(),
			shapeTypes: Array<PropertyType<ShapeType>>(),
		});

		function itemChanged () {
			ctx.emit("refresh-photos", 1, state.selectedItem.id);
		}

		async function addItem () {

			const itemPhoto: ItemPhoto = new ItemPhoto({
				itemId: state.selectedItem.id,
				typeId: 1,
				fileName: "https://i.imgur.com/FbahS46.png",
				alt: "Platinum cushion ring",
			});
			const postedItemPhoto: ItemPhoto = await api.post("itemphotos", itemPhoto);

			const itemPhotoMetalSet: ItemPhotoPropertySet = new ItemPhotoPropertySet({
				itemPhotoId: postedItemPhoto.id,
				propertyId: new Metal().id,
				value: state.selectedMetal.description
			});
			api.post("itemphotopropertysets", itemPhotoMetalSet);

			const itemPhotoShapeSet: ItemPhotoPropertySet = new ItemPhotoPropertySet({
				itemPhotoId: postedItemPhoto.id,
				propertyId: new Shape().id,
				value: state.selectedShape.description
			});
			api.post("itemphotopropertysets", itemPhotoShapeSet);

			ctx.emit("refresh-photos");
		}

		async function fetchItems () {
			state.items.push(state.selectedItem);

			const dbItems = await api.get("items");

			if (!dbItems) {
				return;
			}

			state.items = state.items.concat(dbItems);
		}
		function fetchMetalTypes () {
			state.metalTypes.push(state.selectedMetal);
			const metalTypes = MetalType.getMetalTypes();

			state.metalTypes = state.metalTypes.concat(metalTypes);
		}
		function fetchShapeTypes () {
			state.shapeTypes.push(state.selectedShape);
			const shapeTypes = ShapeType.getShapeTypes();

			state.shapeTypes = state.shapeTypes.concat(shapeTypes);
		}

		onMounted(() => {
			fetchItems();
			fetchMetalTypes();
			fetchShapeTypes();
		});

		return {
			state,
			addItem,
			itemChanged,
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
