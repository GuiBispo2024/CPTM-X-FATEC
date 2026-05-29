/**
 * Constantes da aplicação
 */

export const APP_NAME = 'CPTM Field App'
export const APP_VERSION = '1.0.0'

/**
 * Status de sincronização
 */
export const SYNC_STATUS = {
  PENDING: 'PENDING',
  SYNCED: 'SYNCED',
  ERROR: 'ERROR'
}

/**
 * Tipos de efluente
 */
export const EFLUENTE_TYPES = [
  { value: 'Doméstico', label: 'Doméstico' },
  { value: 'Industrial', label: 'Industrial' },
  { value: 'Agrícola', label: 'Agrícola' },
  { value: 'Misto', label: 'Misto' },
  { value: 'Outro', label: 'Outro' }
]

/**
 * Status de desvio ambiental
 */
export const ENVIRONMENTAL_STATUS = [
  { value: 'Conforme', label: 'Conforme' },
  { value: 'Não Conforme', label: 'Não Conforme' },
  { value: 'Crítico', label: 'Crítico' },
  { value: 'Em Análise', label: 'Em Análise' }
]

/**
 * Linhas CPTM
 */
export const CPTM_LINES = [
  { value: 'Linha 1', label: 'Linha 1 - Azul' },
  { value: 'Linha 2', label: 'Linha 2 - Verde' },
  { value: 'Linha 3', label: 'Linha 3 - Vermelha' },
  { value: 'Linha 4', label: 'Linha 4 - Amarela' },
  { value: 'Linha 5', label: 'Linha 5 - Lilás' },
  { value: 'Linha 6', label: 'Linha 6 - Laranja' },
  { value: 'Linha 7', label: 'Linha 7 - Rubi' },
  { value: 'Linha 8', label: 'Linha 8 - Diamante' },
  { value: 'Linha 9', label: 'Linha 9 - Esmeralda' },
  { value: 'Linha 10', label: 'Linha 10 - Turquesa' },
  { value: 'Linha 11', label: 'Linha 11 - Coral' },
  { value: 'Linha 12', label: 'Linha 12 - Safira' },
  { value: 'Linha 13', label: 'Linha 13 - Jade' },
  { value: 'Linha 15', label: 'Linha 15 - Prata' }
]

/**
 * Mensagens de erro
 */
export const ERROR_MESSAGES = {
  NETWORK_ERROR: 'Erro de conexão. Verifique sua internet.',
  UNAUTHORIZED: 'Não autorizado. Faça login novamente.',
  NOT_FOUND: 'Recurso não encontrado.',
  VALIDATION_ERROR: 'Erro de validação. Verifique os dados.',
  SERVER_ERROR: 'Erro no servidor. Tente novamente mais tarde.',
  UNKNOWN_ERROR: 'Erro desconhecido. Tente novamente.'
}

/**
 * Mensagens de sucesso
 */
export const SUCCESS_MESSAGES = {
  CREATED: 'Criado com sucesso!',
  UPDATED: 'Atualizado com sucesso!',
  DELETED: 'Deletado com sucesso!',
  SYNCED: 'Sincronizado com sucesso!',
  LOGGED_IN: 'Login realizado com sucesso!',
  LOGGED_OUT: 'Logout realizado com sucesso!'
}

/**
 * Timeouts
 */
export const TIMEOUTS = {
  SHORT: 2000,
  MEDIUM: 5000,
  LONG: 10000,
  API_TIMEOUT: 30000
}

/**
 * Intervalos
 */
export const INTERVALS = {
  SYNC_CHECK: 30000, // 30 segundos
  LOCATION_UPDATE: 10000, // 10 segundos
  STATUS_DISPLAY: 3000 // 3 segundos
}

/**
 * Limites
 */
export const LIMITS = {
  MAX_FILE_SIZE: 5 * 1024 * 1024, // 5MB
  MAX_FORM_FIELDS: 100,
  MAX_OBSERVATIONS_LENGTH: 1000,
  MIN_PASSWORD_LENGTH: 6
}

/**
 * Regex patterns
 */
export const PATTERNS = {
  EMAIL: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
  PHONE: /^\(?[1-9]{2}\)?\s?9?\d{4}-?\d{4}$/,
  CPF: /^\d{3}\.\d{3}\.\d{3}-\d{2}$/,
  COORDINATES: /^-?\d+\.?\d*,\s*-?\d+\.?\d*$/
}

/**
 * Cores para badges
 */
export const BADGE_COLORS = {
  success: 'bg-green-100 text-green-800',
  warning: 'bg-yellow-100 text-yellow-800',
  danger: 'bg-red-100 text-red-800',
  info: 'bg-blue-100 text-blue-800'
}

/**
 * Breakpoints responsivos
 */
export const BREAKPOINTS = {
  xs: 0,
  sm: 640,
  md: 768,
  lg: 1024,
  xl: 1280,
  '2xl': 1536
}

/**
 * Rotas da aplicação
 */
export const ROUTES = {
  LOGIN: '/login',
  HOME: '/home',
  FORMULARIO: '/formulario',
  PERFIL: '/perfil',
  FORGOT_PASSWORD: '/forgot-password'
}
