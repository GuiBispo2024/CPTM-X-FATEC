export const geoService = {
  async getCurrentLocation() {
    return new Promise((resolve, reject) => {
      if (!navigator.geolocation) {
        reject(new Error('Geolocalização não suportada neste navegador'))
        return
      }

      navigator.geolocation.getCurrentPosition(
        (position) => {
          const { latitude, longitude, accuracy } = position.coords
          resolve({
            latitude,
            longitude,
            accuracy,
            timestamp: new Date().toISOString(),
            coordenadaGeografica: `${latitude}, ${longitude}`
          })
        },
        (error) => {
          reject(new Error(`Erro ao obter localização: ${error.message}`))
        },
        {
          enableHighAccuracy: true,
          timeout: 10000,
          maximumAge: 0
        }
      )
    })
  },

  watchLocation(callback, errorCallback) {
    if (!navigator.geolocation) {
      errorCallback(new Error('Geolocalização não suportada neste navegador'))
      return null
    }

    const watchId = navigator.geolocation.watchPosition(
      (position) => {
        const { latitude, longitude, accuracy } = position.coords
        callback({
          latitude,
          longitude,
          accuracy,
          timestamp: new Date().toISOString(),
          coordenadaGeografica: `${latitude}, ${longitude}`
        })
      },
      (error) => {
        errorCallback(new Error(`Erro ao observar localização: ${error.message}`))
      },
      {
        enableHighAccuracy: true,
        timeout: 10000,
        maximumAge: 0
      }
    )

    return watchId
  },

  clearWatch(watchId) {
    if (watchId !== null) {
      navigator.geolocation.clearWatch(watchId)
    }
  },

  formatCoordinates(latitude, longitude) {
    return `${latitude.toFixed(6)}, ${longitude.toFixed(6)}`
  },

  calculateDistance(lat1, lon1, lat2, lon2) {
    const R = 6371 // Raio da Terra em km
    const dLat = (lat2 - lat1) * Math.PI / 180
    const dLon = (lon2 - lon1) * Math.PI / 180
    const a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
              Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
              Math.sin(dLon / 2) * Math.sin(dLon / 2)
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a))
    return R * c
  }
}
