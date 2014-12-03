fileSystem = (function(chance) {
	function extend(Child, Parent) {
		var F = function() { };
		F.prototype = Parent.prototype;
		Child.prototype = new F();
		Child.prototype.constructor = Child;
		Child.superclass = Parent.prototype;
	}
	
	function Node() {}
	
	function File() {
		this.name = chance.word();
		this.content = chance.paragraph();
	}
	
	function Folder() {
		this.name = chance.word({syllables: 4});
		this.isLoaded = false;
		this.isLoading = false;
		this.children = null;
	}
	
	extend(File, Node);
	extend(Folder, Node);
	
	File.prototype.isFolder = false;
	Folder.prototype.isFolder = true;
	
	function createLoader(self) {
		var callbacks = [];
		
		self.isLoading = true;
		
		function load(){
			var count = -Math.log(Math.random()) * 10 + 1;
			self.children = [];
			
			for(var i = 0; i < count; i++) {
				if(Math.random() < 0.3) {
					self.children.push(new Folder());
				}
				else {
					self.children.push(new File());
				}
			}
			
			self.isLoaded = true;
			self.isLoading = false;
		}
		
		setTimeout(function() {
			load();
		
			for(var i = 0; i < callbacks.length; i++) {
				callbacks[i].apply(self);
			}
		}, Math.random() * 5000);
		
		return {
			done: function(callback) {
				callbacks.push(callback);
				return this;
			}
		}
	}
	
	var cachedLoaders = [];
	
	function cachedLoaderIndex(folder) {	
		for(var i = 0; i < cachedLoaders.length; i++) {
			if(cachedLoaders[i].folder == folder) {
				return i;
			}
		}
	}
	
	Folder.prototype.loadChildren = function() {
		var self = this;
		if(self.isLoading) {
			cachedLoaders[cachedLoaderIndex(folder)].loader;
		}
		
		var loader = createLoader(self);
		cachedLoaders.push({
			loader: loader,
			folder: self
		});
		
		return loader.done(function() {
			cachedLoaders.splice(cachedLoaderIndex(self), 1);
		});
	}
	
	return new Folder();
})(chance);