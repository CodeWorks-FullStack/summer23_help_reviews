

export class Restaurant {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.imgUrl = data.imgUrl
    this.visits = data.visits
    this.isShutDown = data.isShutDown
    this.creatorId = data.creatorId
    this.creator = data.creator
  }
}

// let object = {
//   "name": "Toucan-ah Savannah's",
//   "description": "It's like the rainforest cafe, but it's more expensive",
//   "imgUrl": "https://resizer.otstatic.com/v2/photos/wide-huge/3/53266111.jpg",
//   "visits": 0,
//   "isShutDown": false,
//   "creatorId": "64ad7dd487ee9a53a0226331",
//   "creator": {
//     "name": "jerms",
//     "picture": "https://plus.unsplash.com/premium_photo-1661892259737-2d658fcf7ebb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80",
//     "id": "64ad7dd487ee9a53a0226331",
//     "createdAt": "2023-08-22T18:48:01",
//     "updatedAt": "2023-08-23T17:48:04"
//   },
//   "id": 2,
//   "createdAt": "2023-08-23T16:13:18",
//   "updatedAt": "2023-08-23T16:13:18"
// }