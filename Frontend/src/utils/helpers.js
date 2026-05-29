/**
 * Formata uma data para o padrão brasileiro
 * @param {string|Date} date - Data a formatar
 * @returns {string} Data formatada
 */
export function formatDate(date) {
  const d = new Date(date)
  return d.toLocaleDateString('pt-BR', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric'
  })
}

/**
 * Formata uma data e hora para o padrão brasileiro
 * @param {string|Date} date - Data a formatar
 * @returns {string} Data e hora formatadas
 */
export function formatDateTime(date) {
  const d = new Date(date)
  return d.toLocaleDateString('pt-BR', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
    second: '2-digit'
  })
}

/**
 * Formata um número como moeda brasileira
 * @param {number} value - Valor a formatar
 * @returns {string} Valor formatado
 */
export function formatCurrency(value) {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(value)
}

/**
 * Valida um email
 * @param {string} email - Email a validar
 * @returns {boolean} True se válido
 */
export function validateEmail(email) {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  return re.test(email)
}

/**
 * Valida uma senha
 * @param {string} password - Senha a validar
 * @returns {object} Objeto com validação e mensagens
 */
export function validatePassword(password) {
  const errors = []

  if (password.length < 6) {
    errors.push('Mínimo 6 caracteres')
  }
  if (!/[a-z]/.test(password)) {
    errors.push('Deve conter letras minúsculas')
  }
  if (!/[A-Z]/.test(password)) {
    errors.push('Deve conter letras maiúsculas')
  }
  if (!/[0-9]/.test(password)) {
    errors.push('Deve conter números')
  }

  return {
    isValid: errors.length === 0,
    errors
  }
}

/**
 * Trunca um texto com reticências
 * @param {string} text - Texto a truncar
 * @param {number} length - Comprimento máximo
 * @returns {string} Texto truncado
 */
export function truncate(text, length = 50) {
  if (text.length <= length) return text
  return text.substring(0, length) + '...'
}

/**
 * Capitaliza a primeira letra de uma string
 * @param {string} str - String a capitalizar
 * @returns {string} String capitalizada
 */
export function capitalize(str) {
  if (!str) return ''
  return str.charAt(0).toUpperCase() + str.slice(1)
}

/**
 * Converte uma string para slug
 * @param {string} str - String a converter
 * @returns {string} Slug
 */
export function toSlug(str) {
  return str
    .toLowerCase()
    .trim()
    .replace(/[^\w\s-]/g, '')
    .replace(/[\s_]+/g, '-')
    .replace(/^-+|-+$/g, '')
}

/**
 * Gera um ID único
 * @returns {string} ID único
 */
export function generateId() {
  return `${Date.now()}-${Math.random().toString(36).substr(2, 9)}`
}

/**
 * Calcula o tempo decorrido desde uma data
 * @param {string|Date} date - Data de referência
 * @returns {string} Tempo decorrido em formato legível
 */
export function timeAgo(date) {
  const d = new Date(date)
  const now = new Date()
  const seconds = Math.floor((now - d) / 1000)

  let interval = seconds / 31536000
  if (interval > 1) return Math.floor(interval) + ' anos atrás'

  interval = seconds / 2592000
  if (interval > 1) return Math.floor(interval) + ' meses atrás'

  interval = seconds / 86400
  if (interval > 1) return Math.floor(interval) + ' dias atrás'

  interval = seconds / 3600
  if (interval > 1) return Math.floor(interval) + ' horas atrás'

  interval = seconds / 60
  if (interval > 1) return Math.floor(interval) + ' minutos atrás'

  return Math.floor(seconds) + ' segundos atrás'
}

/**
 * Copia um texto para a área de transferência
 * @param {string} text - Texto a copiar
 * @returns {Promise<boolean>} True se copiado com sucesso
 */
export async function copyToClipboard(text) {
  try {
    await navigator.clipboard.writeText(text)
    return true
  } catch (err) {
    console.error('Erro ao copiar:', err)
    return false
  }
}

/**
 * Faz download de um arquivo
 * @param {string} url - URL do arquivo
 * @param {string} filename - Nome do arquivo
 */
export function downloadFile(url, filename) {
  const link = document.createElement('a')
  link.href = url
  link.download = filename
  document.body.appendChild(link)
  link.click()
  document.body.removeChild(link)
}

/**
 * Valida coordenadas geográficas
 * @param {string} coords - Coordenadas no formato "latitude, longitude"
 * @returns {boolean} True se válido
 */
export function validateCoordinates(coords) {
  const parts = coords.split(',').map(p => p.trim())
  if (parts.length !== 2) return false

  const lat = parseFloat(parts[0])
  const lon = parseFloat(parts[1])

  return lat >= -90 && lat <= 90 && lon >= -180 && lon <= 180
}

/**
 * Formata coordenadas geográficas
 * @param {number} latitude - Latitude
 * @param {number} longitude - Longitude
 * @param {number} precision - Casas decimais
 * @returns {string} Coordenadas formatadas
 */
export function formatCoordinates(latitude, longitude, precision = 6) {
  return `${latitude.toFixed(precision)}, ${longitude.toFixed(precision)}`
}

/**
 * Debounce para funções
 * @param {Function} func - Função a executar
 * @param {number} wait - Tempo de espera em ms
 * @returns {Function} Função com debounce
 */
export function debounce(func, wait) {
  let timeout
  return function executedFunction(...args) {
    const later = () => {
      clearTimeout(timeout)
      func(...args)
    }
    clearTimeout(timeout)
    timeout = setTimeout(later, wait)
  }
}

/**
 * Throttle para funções
 * @param {Function} func - Função a executar
 * @param {number} limit - Tempo de limite em ms
 * @returns {Function} Função com throttle
 */
export function throttle(func, limit) {
  let inThrottle
  return function(...args) {
    if (!inThrottle) {
      func.apply(this, args)
      inThrottle = true
      setTimeout(() => (inThrottle = false), limit)
    }
  }
}
