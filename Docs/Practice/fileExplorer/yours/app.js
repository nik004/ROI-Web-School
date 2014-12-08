$(function() {
	var name = fileSystem.name;

	var root = $("#folder")
		.clone()
		.removeAttr("id")
		.appendTo("#tree")
		.find(".caption")
		.text(name)
		.end()
		.click(function(event) {
			event.stopPropagation();
			
			var self = $(this);
			var children = self.find(".list-group");
			
			if(fileSystem.isLoaded) {
				children.slideToggle();
				return;
			}
			
			self.addClass("loading");
			
			fileSystem.loadChildren().done(function() {
				for(var i = 0; i < fileSystem.children.length; i++) {
					if(fileSystem.children[i].isFolder) {
						$("#folder")
							.clone()
							.removeAttr("id")
							.appendTo(children)
							.find(".caption")
							//.data("file", fileSystem.children[i])
							//later: .data("file").content
							.text(fileSystem.children[i].name);
					} else {
						// TODO: add files
					}
				}

				self.removeClass("loading");
				children.slideDown();
			});
		});
	
	// TODO: add files
});