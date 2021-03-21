<template>

	<div class="actions-header">

		<div class="p-2">Amount of pictures: {{state.filteredPhotos.length}}</div>
		<div class="p-2 d-flex justify-content-center">

			<div class="row no-gutters">
				<div class="p-1">
					<div>Ring</div>

					<select v-model="state.selectedItem" @change="changeFilter()">
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

					<select v-model="state.selectedMetal" @change="changeFilter()">
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

					<select v-model="state.selectedShape" @change="changeFilter()">
						<option
							v-for="(shapeType) in state.shapeTypes"
							:key="shapeType.id"
							:value="shapeType">
							{{ shapeType.description }}
						</option>
					</select>
				</div>
			</div>
		</div>

		<div class="row no-gutters add-container">

			<div class="p-1">
				<a href="https://imgur.com/upload" target="_blank" class="small row no-gutters">
					Please use imgur to guarantee a working url<br>
					(right click "view image" once uplodaded)
				</a>

				<input :disabled="!canAdd" type="text" v-model="state.imageUrl" placeholder="Your url..."
					:class="state.imageUrl.length > 50 ? 'bg-danger' : ''">

				<div v-if="state.imageUrl.length > 50">Url too long! (Max 50)</div>
			</div>

			<div class="p-2">
				<button
					:disabled="!canAdd"
					class="btn btn-success"
					@click="addItem()">
					+ Add
				</button>
			</div>
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
			filteredPhotos: props.itemPhotos,
			selectedItem: Item.getNullSelectedItem(),
			selectedMetal: Property.getNullSelectedPropertyType<MetalType>(),
			selectedShape: Property.getNullSelectedPropertyType<ShapeType>(),
			imageUrl: "https://i.imgur.com/sTTooHf.jpg",
			items: Array<Item>(),
			metalTypes: Array<PropertyType<MetalType>>(),
			shapeTypes: Array<PropertyType<ShapeType>>(),
		});

		const canAdd = computed(() => {
			const isItemSelected: boolean = state.selectedItem.id !== 0;
			const isMetalSelected: boolean = state.selectedMetal.id !== 0;
			const isShapeSelected: boolean = state.selectedShape.id !== 0;

			return isItemSelected && isMetalSelected && isShapeSelected;
		});

		function changeFilter () {
			state.filteredPhotos = props.itemPhotos;

			//Filter by item
			if (state.selectedItem.id > 0) {
				state.filteredPhotos = state.filteredPhotos.filter(photo => photo.itemId == state.selectedItem.id);
			}

			//Filter by metal
			if (state.selectedMetal.id > 0) {
				state.filteredPhotos = state.filteredPhotos.filter(photo => {
					const property: ItemPhotoPropertySet = photo.itemPhotoPropertySets.find(property => property.propertyId == new Metal().id) ?? new ItemPhotoPropertySet();

					let filtered = property.value === state.selectedMetal.description

					return filtered;
				});
			}

			//Filter by shape
			if (state.selectedShape.id > 0) {
				state.filteredPhotos = state.filteredPhotos.filter(photo => {
					const property: ItemPhotoPropertySet = photo.itemPhotoPropertySets.find(property => property.propertyId == new Shape().id) ?? new ItemPhotoPropertySet();

					let filtered = property.value === state.selectedShape.description

					return filtered;
				});
			}

			ctx.emit("photos-filtered", state.filteredPhotos);

		}

		function resetState() {
			state.filteredPhotos = props.itemPhotos;
			state.selectedShape = Property.getNullSelectedPropertyType<ShapeType>();
			state.selectedMetal = Property.getNullSelectedPropertyType<MetalType>();
			state.selectedItem = Item.getNullSelectedItem();
			state.imageUrl = "";
		}

		async function addItem () {

			if (state.imageUrl.length > 50) {
				return;
			}

			const itemPhoto: ItemPhoto = new ItemPhoto({
				itemId: state.selectedItem.id,
				typeId: 1,
				fileName: state.imageUrl,
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
			resetState();

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
			state.filteredPhotos = props.itemPhotos;
			fetchItems();
			fetchMetalTypes();
			fetchShapeTypes();
		});

		return {
			state,
			canAdd,
			addItem,
			changeFilter,
			resetState,
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
