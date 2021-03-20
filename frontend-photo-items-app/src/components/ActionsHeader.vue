<template>

	<div class="actions-header">
		<div class="p-2">Actions</div>
	</div>

</template>

<script lang="ts">
import { defineComponent} from "vue";

export default defineComponent({
  name: "ActionsHeader",

	setup (props, ctx) {
    
		return {
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
